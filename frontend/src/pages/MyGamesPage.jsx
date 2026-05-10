import { useEffect, useState } from "react";
import Navbar from "../components/Navbar";
import api from "../services/api";
import GameCard from "../components/GameCard";

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

    async function deleteGame(id) {
        try {
            await api.delete(`/backlog/${id}`);

            setGames(
                games.filter((g) => g.gameEntryID !== id)
            );
        } catch (error) {
            console.log(error);
        }
    }

    async function updateGame(id, updatedGame) {
        try {
            await api.put(
                `/backlog/${id}`,
                updatedGame
            );
        } catch (error) {
            console.log(error);
        }
    }

    return (
        <div className="min-h-screen bg-zinc-950 text-white p-8">

            <Navbar />


            <h1 className="text-5xl font-bold mb-8">
                My Games
            </h1>

            <div className="grid
                grid-cols-1
                sm:grid-cols-2
                md:grid-cols-3
                lg:grid-cols-4
                gap-6">

                {games.map((game) => (

                    <GameCard
                        key={game.gameID}
                        game={game}
                        onDelete={deleteGame}
                        onUpdate={updateGame}
                    />

                ))}

            </div>

        </div>
    );
}

export default MyGamesPage;