import { Link, useNavigate } from "react-router-dom";

function Navbar() {
    const navigate = useNavigate();

    function handleLogout() {
        localStorage.removeItem("token");

        navigate("/login");
    }

    return (
        <nav>

            <Link to="/mygames">
                My Games
            </Link>

            {" | "}

            <button onClick={handleLogout}>
                Logout
            </button>

        </nav>
    );
}

export default Navbar;