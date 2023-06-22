// Allows access to every view.

import React from "react";
import { Routes, Route, Navigate } from "react-router-dom";
import Homepage from "./Homepage";
import Profile from "./profile/Profile";
import Gamelist from "./games/GameList";
import CoinGame from "./games/coinGame/CoinGame";
import HorseGame from "./games/horseGame/HorseGame";
import CardGame from "./games/cardGame/CardGame";
import NotFound from "./NotFound";

const ApplicationView = () => {
    return (
        <Routes>
            <Route path="/">
                <Route index element={<Homepage />} />
                <Route path="games" element={<Gamelist />}>
                    <Route path="coingame" element={<CoinGame />} />
                    <Route path="horsegame" element={<HorseGame />} />
                    <Route path="cardgame" element={<CardGame />} />
                    <Route path="*" element={<NotFound />} />
                </Route>
                <Route path="profile" element={<Profile />} />
                <Route path="*" element={<NotFound />} />
            </Route>
            <Route path="*" element={<NotFound />} />
        </Routes>
    )
}

export default ApplicationView;