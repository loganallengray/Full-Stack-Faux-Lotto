// Allows access to every view.

import { Routes, Route, Navigate } from "react-router-dom";
import Homepage from "./Homepage";

const ApplicationView = () => {
    return (
        <Routes>
            <Route path="/">
                <Route index element={<Homepage />} />
            </Route>
        </Routes>
    )
}

export default ApplicationView;