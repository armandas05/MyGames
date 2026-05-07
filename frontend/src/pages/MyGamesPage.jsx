import { useEffect, useState } from "react";
import api from "../services/api";

function MyGamesPage() {
    const [games, setGames] = useState([]);

    useEffect(() => {
        fetchGames();
    }, []);

    async function fetchGames() {
        try {
            const response = await api.get("/backlog");

            setGames(response.data);

        } catch (error) {
            console.log(error);
        }
    }

    return (
        <div>

            <h1>My Games</h1>

            {games.map((game) => (

                <div key={game.gameID}>

                    <h3>{game.gameName}</h3>

                    <p>Status: {game.status}</p>

                </div>
                
            ))}

        </div>
    );
}

export default MyGamesPage;