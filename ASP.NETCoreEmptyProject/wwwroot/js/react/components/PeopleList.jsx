
import Details from "./Person.jsx";

function PeopleList(props) {

    const [people, setPeople] = React.useState([]);
    const [languages, setLanguages] = React.useState([]);
    const [cities, setCities] = React.useState([]);
    const [searchText, setSearchText] = React.useState("");
    const [selectedPerson, setSelectedPerson] = React.useState({});

    const deletePerson = async (Id) => {
        let data = await axios.delete("/React/People/" + selectedPerson.Id);

        setPeople(people.filter(function (val, indx, arr) {
            return val.Id !== Id
        }));
        setSelectedPerson(data);
    }

    const updatePersonDetails = async (Id) => {
        try {

            let data = await axios.get("/React/People/" + Id)
                .then(({ data }) => data);
            setSelectedPerson(data);
        } catch (errors) {
            console.log(errors);
        }
    }

    const getLanguages = async () => {
        try {
            let data = await axios.get("/React/Languages").then(({ data }) => data);
            setLanguages(data);
        } catch (error) {

        }
    }

    const getCities = async () => {
        try {
            let data = await axios.get("/React/Cities").then(({ data }) => data);
            setCities(data);
        } catch (error) {

        }
    }

    const getPeople = async () => {
        try {
            let data = await axios.get("/React/People").then(({ data }) => data)
            setPeople(data)
        } catch (errors) {
            console.error(errors);
        }
    }


    React.useEffect(
        () => {
            getPeople()
            getCities()
            getLanguages()
        }, []);

    return (
        <>
            <div className="d-flex flex-wrap">
                <Details person={selectedPerson} onDeletePerson={deletePerson} />
            </div>
            <div className="mt-2">
                <input onChange={(e) => setSearchText(e.target.value)} className="form-control" type="text"
                    placeholder="Filter by name" />
            </div>
            <table className="table table-hover">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Name</th>
                        <th scope="col">Country</th>
                        <th scope="col">City</th>
                        <th scope="col">Phone</th>
                    </tr>
                </thead>
                <tbody>
                    {people.filter((person) => person.Name.includes(searchText)).map(person =>
                        <tr style={{ cursor: "pointer" }} key={person.Id} onClick={() => updatePersonDetails(person.Id)}>
                            <td>
                                {person.Id}
                            </td>
                            <td>
                                {person.Name}
                            </td>
                            <td>
                                {person.CountryName}
                            </td>
                            <td>
                                {person.CityName}
                            </td>
                            <td>
                                {person.Phone}
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>
        </>
    )

}

export default PeopleList;