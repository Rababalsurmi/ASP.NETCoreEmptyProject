class PersonBox extends React.Component {
    render() {
        return (
            <div className="personBox">Hello, World! I am a person Box.</div>
        );
    }
}

ReactDOM.render(<PersonBox />, document.getElementById('content'));