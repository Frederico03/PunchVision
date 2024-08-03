import React, { useRef, useEffect } from "react";
// javascript plugin used to create scrollbars on windows
import PerfectScrollbar from "perfect-scrollbar";

// reactstrap components
import { Route, Routes, useLocation, Link } from "react-router-dom";

// core components
import DemoNavbar from "components/Navbars/DemoNavbar.js";
import Footer from "components/Footer/Footer.js";
import Sidebar from "components/Sidebar/Sidebar.js";

import routes from "routes.js";

function Admin(props) {
  var ps;
  const location = useLocation();
  const backgroundColor = 'red';
  const mainPanel = useRef();

  useEffect(() => {
    const isWindows = navigator.userAgent.includes("Windows");

    if (isWindows) {
      ps = new PerfectScrollbar(mainPanel.current);
      document.body.classList.add("perfect-scrollbar-on");
    }

    return () => {
      if (isWindows && ps) {
        ps.destroy();
        document.body.classList.remove("perfect-scrollbar-on");
      }
    };
  }, [mainPanel]);

  useEffect(() => {
    document.documentElement.scrollTop = 0;
    document.scrollingElement.scrollTop = 0;
    mainPanel.current.scrollTop = 0;
  }, [location]);

  return (
    <div className="wrapper">
      <Sidebar {...props} routes={routes} backgroundColor={backgroundColor} />
      <div className="main-panel" ref={mainPanel}>
        <DemoNavbar {...props} />
        <Routes>
          {routes.map((prop, key) => {
            return (
              <Route
                path={prop.path}
                element={prop.component}
                key={key}
                exact
              />
            );
          })}
          <Route
            path="/admin"
            element={<Link to="/admin/dashboard" replace />}
          />
        </Routes>
        <Footer fluid />
      </div>
    </div>
  );
}

export default Admin;
