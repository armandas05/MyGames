import { BrowserRouter, Routes, Route } from "react-router-dom";
import LoginPage from "./pages/LoginPage";
import MyGamesPage from "./pages/MyGamesPage";
import ProtectedRoute from "./components/ProtectedRoute";

function App() {
  return (
    <BrowserRouter>

      <Routes>

        <Route 
          path="/login" 
          element={<LoginPage />} 
        />

        <Route
          path="/mygames"
          element={
            <ProtectedRoute>
              <MyGamesPage />
            </ProtectedRoute>
          }
        />

      </Routes>

    </BrowserRouter>
  );
}

export default App;