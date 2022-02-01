

function Details(props) {
    const [person, setPerson] = React.useState({});

    const deletePerson = () => {
        props.onDeletePerson(props.person.Id);
        setPerson({});
    }

    return (
        <div className="card" style={{ minWidth: "60rem" }} hidden={props.person.Id === undefined}>
            <header className="card-header">
                <div className="row">
                    <h3 className="col">{props.person.Name}</h3>
                    <div className="col-sm">

                        <button className="text-right" onClick={() => deletePerson()}
                            className="btn btn-danger outlined">Delete
                        </button>
                    </div>
                </div>
            </header>
            <div className="card-body">
                <div className="">
                    <div className="row">
                        <p className="card-text font-weight-bold col">Id:</p>
                        <p className="card-text col">{props.person.Id}</p>
                    </div>
                    <div className="row">
                        <p className="card-text font-weight-bold col">Name:</p>
                        <p className="card-text col">{props.person.Name}</p>
                    </div>
                    <div className="row">
                        <p className="card-text font-weight-bold col">Country:</p>
                        <p className="card-text col">{props.person.CountryName}</p>
                    </div>
                    <div className="row">
                        <p className="col card-text font-weight-bold">City:</p>
                        <p className="col card-text ">{props.person.CityName}</p>
                    </div>
                </div>
                <div className="row">
                    <p className="col card-text font-weight-bold">
                        Languages:
                    </p>
                    <ul className="col list-inline">

                        {props.person.Languages !== undefined &&
                            props.person.Languages.map(language =>
                                <li className="list-inline-item" key={language}>{language}</li>
                            )
                        }
                    </ul>
                </div>
            </div>
        </div>
    )

}

export default Details;