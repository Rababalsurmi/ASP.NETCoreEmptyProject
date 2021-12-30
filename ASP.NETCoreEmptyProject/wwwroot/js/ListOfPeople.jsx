class CityRow extends React.Component {
    render() {
        const city = this.props.city;
        const country = this.props.country;
        return (
            <tr>
                <th colSpan="2">
                    {city}
                    {country}
                </th>
            </tr>
        );
    }
}

class PersonRow extends React.Component {
    render() {
        const person = this.props.person;
        const name = person.Id ?
            person.name :
            <span style={{ color: 'red' }}>
                {person.name}
            </span>;

        return (
            <tr>
                <td>{person.Id}</td>
                <td>{name}</td>
                <td>{person.language}</td>
                <td>{person.city}</td>
                <td>{person.country}</td>
            </tr>
        );
    }
}

class PersonTable extends React.Component {
    render() {

        const rows = [];
        let lastCity = null;

        this.props.people.forEach((person) => {
           
            //if (person.city !== lastCity) {
            //    rows.push(
            //        <CityRow
            //            city={person.city}
            //            key={person.city} />
            //    );
            //}
            rows.push(
                <PersonRow
                    person={person}
                    key={person.Id} />
            );
            lastCity = person.city;
        });

        return (
            <table className="table">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Language</th>
                        <th>City</th>
                        <th>Country</th>
                    </tr>
                </thead>
                <tbody>{rows}</tbody>
            </table>
        );
    }
}



class ViewPersonTable extends React.Component {
  render() {
        return (
            <div className="viewTable">
                <PersonTable people={this.props.people} />
              
            </div>
        );
    }
}

function GetAllPeople() {
    $.get("/React/GetPeople", null, function (data) {
        $("#list").html(data);
    });
}
const PEOPLE = [
    { city: 'Paris', country: 'France', language: 'French and Englis',  name: 'John', Id: '1' },
    { city: 'Göteborg', country: 'Sweden', language: 'Swedish and English', name: 'Tom', Id: '2'  },
    { city: 'Skövde', country: 'Sweden', language: 'Spanish, Swedish and English', name: 'Simon', Id: '3' },
    { city: 'Jönköping', country: 'Sweden', language: 'Swedish, Norwegian and English', name: 'Alex', Id: '4' },
    { city: 'Kungälv', country: 'Sweden', language: 'Swedish and English', name: 'Hugo', Id: '5' },
    { city: 'Stockholm', country: 'Sweden', language: 'Swedish, German and English', name: 'Michael', Id: '6' }
];

ReactDOM.render(
    <ViewPersonTable people={PEOPLE} />,
    
    document.getElementById('content')
);
