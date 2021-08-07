class UserDateList extends React.Component {
    constructor(props) {
        super(props);
        this.state = { userDates: []};

        this.onAddUserDateList = this.onAddUserDateList.bind(this);
        this.addRow = this.addRow.bind(this);
        this.onChangeDateRegistration = this.onChangeDateRegistration.bind(this);
        this.onChangeDateLastActivity = this.onChangeDateLastActivity.bind(this);
    }

    onChangeDateRegistration = (id, e) =>
        this.setState({ [userDates[id].dateRegistration] : e.target.value });

    onChangeDateLastActivity = (id, e) =>
        this.setState({ [userDates[id].dateLastActivity]: e.target.value });

    rowCounter(prewState, props) {
        return {
            userDates: prewState.userDates.push({ id: prewState.userDates.length + 1, dateRegistration: "", dateLastActivity : ""})
        };
    }

    addRow() {
        this.setState(this.rowCounter);
    }

    //addRow() {
    //    this.setState({ userDates: userDates.push({ id: userDates.length + 1, dateRegistration: "", dateLastActivity: "" }) });
    //}

    loadData() {
        var xhr = new XMLHttpRequest();
        xhr.open("get", this.props.apiUrl, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ userDates: data });
        }.bind(this);
        xhr.send();
    }
    componentDidMount() {
        this.loadData();
    }
    onAddUserDateList(userDates) {
        if (userDates) {

            const data = new FormData();
            for (const element of userDates) {
                data.append("userDate[]", element);
            }
            
            var xhr = new XMLHttpRequest();

            xhr.open("post", this.props.apiUrl, true);
            xhr.onload = function () {
                if (xhr.status === 200) {
                    this.loadData();
                }
            }.bind(this);
            xhr.send(data);
        }
    }
    render() {
        
        return <div>
            <table>
                <thead>
                    <tr>
                        <th>UserID</th>
                        <th>Date Registration</th>
                        <th>Date Last Activity</th>
                    </tr>
                </thead>
                <tbody>
                    {this.state.userDates.map(userDate => 
                         
                            <tr key={userDate.id}>
                                <td>{userDate.id}</td>
                                <td><input type="date" value={userDate.dateRegistration.substr(0, 10)} onChange={(e) => this.onChangeDateRegistration(userDate.id , e)} /></td>
                                <td><input type="date" value={userDate.dateLastActivity.substr(0, 10)} onChange={(e) => this.onChangeDateLastActivity(userDate.id, e)}/></td>
                                
                            </tr>
                            
                    )}
                </tbody>
            </table>
            <button onClick={() => this.addRow}>+</button>
            <button onClick={() => this.onAddUserDateList(this.state.userDates)}>Save</button>
        </div>;
    }
}
ReactDOM.render(
    <UserDateList apiUrl="/api/index" />,
    document.getElementById("content")
);