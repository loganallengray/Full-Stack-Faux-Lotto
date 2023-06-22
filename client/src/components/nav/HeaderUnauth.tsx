// Lists views available to unauthentificated users.
// Login and Register links at the top right.
// Homepage, Gamelist, Login, and Register are all available.

import { Link } from "react-router-dom";
import { Nav, NavItem } from "reactstrap";

const HeaderUnauth = () => {
    return (
        <Nav>
            <NavItem><Link to="">Faux Lotto</Link></NavItem>
            <NavItem><Link to="games">Games</Link></NavItem>
            <NavItem><Link to="login">Login</Link></NavItem>
            <NavItem><Link to="register">Register</Link></NavItem>
        </Nav>
    )
}

export default HeaderUnauth;