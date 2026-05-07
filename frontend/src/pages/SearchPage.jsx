import { useState } from "react";
import api from "../services/api";

function SearchPage() {
    const [query, setQuery] = useState("");
    const [games, setGames] = useState([]);

    async function handleSearch() {
        try {
            console.log(query);

            const response = await api.get(
                `/games/search?query=${query}`
            );

            setGames(response.data);
        } catch (error) {
            console.log(error);
        }
    }

    return (
        <div>
            <h1>Search Games</h1>

            <input
                type="text"
                placeholder="Search game..."
                value={query}
                onChange={(e) => setQuery(e.target.value)}
            />

            <button onClick={handleSearch}>
                Search
            </button>

            <div>

                {games.map((game) => (
                    <div key={game.id}>

                        <h3>{game.name}</h3>

                        <p>{game.released}</p>

                        <img
                            src={game.backgroundImage}
                            width="200"
                        />

                    </div>

                ))}

            </div>

        </div>
    );
}

export default SearchPage;