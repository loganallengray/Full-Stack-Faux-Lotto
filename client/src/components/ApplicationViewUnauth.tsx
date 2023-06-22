// Allows access to most views.
// Homepage, Gamelist, Login, and Register are all available.

import { Route, Routes } from "react-router-dom";
import Homepage from "./Homepage";
import Gamelist from "./games/GameList";
import NotFound from "./NotFound";
import Login from "./auth/Login";
import Register from "./auth/Register";

const ApplicationViewUnauth = () => {
    return (
        <>
            <Routes>
                <Route path="/">
                    <Route index element={<Homepage />} />
                    <Route path="games" element={<Gamelist />}>
                        <Route path="*" element={<NotFound />} />
                    </Route>
                    <Route path="login" element={<Login />} />
                    <Route path="register" element={<Register />} />
                    <Route path="*" element={<NotFound />} />
                </Route>
                <Route path="*" element={<NotFound />} />
            </Routes>
        </>
    )
}

export default ApplicationViewUnauth;