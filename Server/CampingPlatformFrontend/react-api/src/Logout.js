import { removeUserSession } from './utils/Common';

function Logout(props) {
    const handleLogout = () => {
        removeUserSession();
    }

    return(
        handleLogout()
    )
}

export default Logout;