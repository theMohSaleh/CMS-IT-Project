import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import Menu from "./components/Menu";
import Login from "./components/Login";
import Register from "./components/Register";
import Cart from "./components/Cart";
import AddItem from "./components/AddItem"; 
import Sales from "./components/Sales";
import EditMenu from "./components/EditMenu";
import EditItem from "./components/EditItem";
import EditMenuItems from "./components/EditMenuItems";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/counter',
        element: <Counter />
    },
    {
        path: '/fetch-data',
        element: <FetchData />
    },
    {
        path: '/items',
        element: <Menu />
    },
    {
        path: '/login',
        element: <Login />
    },
    {
        path: '/register',
        element: <Register />
    },
    {
        path: '/cart',
        element: <Cart />
    },
    {
        path: '/addItem',
        element: <AddItem />
    },
    {
        path: '/sales',
        element: <Sales />
    },
    {
        path: '/editMenu',
        element: <EditMenu />
    },
    {
        path: '/editItem',
        element: <EditItem />
    },
    {
        path: '/test',
        element: <EditMenuItems />
    }
];

export default AppRoutes;
