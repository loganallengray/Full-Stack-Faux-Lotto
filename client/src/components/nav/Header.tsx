// Lists all available views
// Displays username and logout button at the top right

import { Link } from "react-router-dom";
import { Nav, NavItem } from "reactstrap";

const Header = () => {
    const logoutHandler = () => {
        console.log("logged out");
    }

    return (
        <Nav>
            <NavItem><Link to="">Faux Lotto</Link></NavItem>
            <NavItem><Link to="games">Games</Link></NavItem>
            <NavItem><Link to="profile">Profile</Link></NavItem>
            <NavItem><span onClick={logoutHandler}>Logout</span></NavItem>
        </Nav>
    )
}

export default Header;