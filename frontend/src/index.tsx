import React from "react";
import ReactDOM from "react-dom";
import App from "./app"
import "./index.styles.css"
import { MemoryRouter } from "react-router-dom";

ReactDOM.render(
  <MemoryRouter>
    <App />
  </MemoryRouter>
  ,
  document.getElementById("root")
);

