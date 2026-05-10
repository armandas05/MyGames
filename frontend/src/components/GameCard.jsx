import { useState } from "react";

function GameCard({ game, onDelete, onUpdate }) {

    const [status, setStatus] = useState(game.status);
    const [rating, setRating] = useState(game.rating || "");
    const [progress, setProgress] = useState(game.progress || "");
    const [notes, setNotes] = useState(game.notes || "");

    function handleUpdate() {

        onUpdate(
            game.gameEntryID,
            {
                status,
                rating,
                progress,
                notes
            }
        );
    }

    return (
        <div className="
            bg-zinc-900
            rounded-2xl
            overflow-hidden
            shadow-lg
        ">

            <img
                src={game.backgroundImage}
                className="w-full h-64 object-cover"
            />

            <div className="p-4 space-y-4">

                <h2 className="text-xl font-bold">
                    {game.gameName}
                </h2>

                <select
                    value={status}
                    onChange={(e) => setStatus(e.target.value)}
                    className="
                        bg-zinc-800
                        border
                        border-zinc-700
                        rounded-xl
                        px-3
                        py-2
                        w-full
                    "
                >
                    <option value="PlanToPlay">
                        Plan To Play
                    </option>

                    <option value="Playing">
                        Playing
                    </option>

                    <option value="Completed">
                        Completed
                    </option>

                    <option value="Dropped">
                        Dropped
                    </option>
                </select>

                <input
                    type="number"
                    placeholder="Rating"
                    value={rating}
                    onChange={(e) => setRating(e.target.value)}
                    className="
                        bg-zinc-800
                        border
                        border-zinc-700
                        rounded-xl
                        px-3
                        py-2
                        w-full
                    "
                />

                <input
                    type="number"
                    placeholder="Progress"
                    value={progress}
                    onChange={(e) => setProgress(e.target.value)}
                    className="
                        bg-zinc-800
                        border
                        border-zinc-700
                        rounded-xl
                        px-3
                        py-2
                        w-full
                    "
                />

                <textarea
                    placeholder="Notes..."
                    value={notes}
                    onChange={(e) => setNotes(e.target.value)}
                    className="
                        bg-zinc-800
                        border
                        border-zinc-700
                        rounded-xl
                        px-3
                        py-2
                        w-full
                    "
                />

                <button
                    onClick={handleUpdate}
                    className="
                        bg-blue-600
                        hover:bg-blue-700
                        rounded-xl
                        px-4
                        py-2
                        w-full
                    "
                >
                    Save
                </button>

                <button
                    onClick={() => onDelete(game.gameEntryID)}
                    className="
                        bg-red-600
                        hover:bg-red-700
                        rounded-xl
                        px-4
                        py-2
                        w-full
                    "
                >
                    Delete
                </button>

            </div>

        </div>
    );
}

export default GameCard;