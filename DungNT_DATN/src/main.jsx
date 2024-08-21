// import React from 'react'
import ReactDOM from "react-dom/client";
import App from "./App.jsx";
// import "./assets/css/antdcustomcss.css";
import "./index.css";
import { Provider } from "react-redux";
import React from "react";
import store from "./reducers/store.js";
import 'react-calendar/dist/Calendar.css';


ReactDOM.createRoot(document.getElementById("root")).render(
  // <React.StrictMode>
    <Provider store={store}>
      <App />
    </Provider>
  // </React.StrictMode>
);
