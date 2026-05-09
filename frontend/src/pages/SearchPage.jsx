import { useState } from "react";
import api from "../services/api";

function SearchPage() {
    const [query, setQuery] = useState("");
    const [games, setGames] = useState([]);

    async function handleSearch() {
        try {
            const response = await api.get(
                `/games/search?query=${query}`
            );

            setGames(response.data);
        } catch (error) {
            console.log(error);
        }
    }

    async function addGame(game) {
        try {
            await api.post(
                "/backlog", {
                    gameID: game.id,
                    gameName: game.name,
            });
        } catch (error) {
            console.log(error);
        }
    }


    return (
        <div className="min-h-screen bg-zinc-950 text-white p-8">
            <h1 className="text-5xl font-bold mb-8">
                Search Games
            </h1>

            <input
                type="text"
                placeholder="Search game..."
                value={query}
                onChange={(e) => setQuery(e.target.value)}
                className="
                bg-zinc-900
                border
                border-zinc-700
                rounded-xl
                px-4
                py-3
                w-full"
            />

            <button 
                onClick={handleSearch}
                className="
                bg-blue-600
                hover:bg-blue-700
                px-6
                rounded-xl
                font-semibold">
                Search
            </button>

            <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 xl:grid-cols-5 gap-6">

                {games.map((game) => (
                    <div 
                        key={game.id}
                        className="
                            bg-zinc-900
                            rounded-2x1
                            overflow-hidden
                            shadow-lg">


                        <h3 className="text-xl font-bold mb-2">
                            {game.name}
                        </h3>

                        <p className="text-zinc-400 mb-4">
                            {game.released}
                        </p>

                        <img
                            src={game.backgroundImage}
                            className="w-full h-60 object-cover"
                        />

                        <button 
                            onClick={() => addGame(game)}
                            className="
                                bg-green-600
                                hover:bg-green-700
                                px-4
                                py-2
                                rounded-xl
                                w-full">
                            Add Game
                        </button>

                    </div>
                ))}


            </div>

        </div>
    );
}

export default SearchPage;