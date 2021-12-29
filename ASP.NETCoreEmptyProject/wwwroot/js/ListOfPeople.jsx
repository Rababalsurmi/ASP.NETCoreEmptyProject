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
        const name = person.name ?
            person.name :
            <span style={{ color: 'red' }}>
                {person.name}
            </span>;

        return (
            <tr>
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
                    key={person.name} />
            );
            lastCity = person.city;
        });

        return (
            <table>
                <thead>
                    <tr>
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

class SearchBar extends React.Component {
    render() {
        return (
            <form>
                <input type="text" placeholder="Search..." />
                <p>
                    <input type="checkbox" />
                    {' '}
          Only show person name
        </p>
            </form>
        );
    }
}

class FilterablePersonTable extends React.Component {
    render() {
        return (
            <div>
                <SearchBar />
                <PersonTable people={this.props.people} />
            </div>
        );
    }
}


const PEOPLE = [
    { city: 'Paris', country: 'France', language: 'French and Englis',  name: 'John' },
    { city: 'Göteborg', country: 'Sweden', language: 'Swedish and English',  name: 'Tom' },
    { city: 'Skövde', country: 'Sweden',language: 'Arabic, Swedish and English',  name: 'Simon' },
    { city: 'Jönköping', country: 'Sweden', language: 'Swedish, Norwegian and English',  name: 'Alex' },
    { city: 'Kungälv', country: 'Sweden',language: 'Swedish and English',  name: 'Hugo' },
    { city: 'Stockholm', country: 'Sweden',language: 'Swedish, German and English',  name: 'Michael' }
];

ReactDOM.render(
    <FilterablePersonTable people={PEOPLE} />,
    document.getElementById('content')
);