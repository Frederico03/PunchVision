/*eslint-disable*/
import React, { useRef, useEffect } from "react";
import { NavLink, useLocation } from "react-router-dom";
import { Nav } from "reactstrap";
// javascript plugin used to create scrollbars on windows
import PerfectScrollbar from "perfect-scrollbar";

import logo from "../../assets/img/icon.png";

var ps;

function Sidebar(props) {
  const sidebar = useRef();
  const location = useLocation();
  // verifies if routeName is the one active (in browser input)
  const activeRoute = (routeName) => {
    return location.pathname.indexOf(routeName) > -1 ? "active" : "";
  };

  useEffect(() => {
    const isWindows = navigator.userAgent.includes("Windows");

    if (isWindows) {
      ps = new PerfectScrollbar(sidebar.current, {
        suppressScrollX: true,
        suppressScrollY: false,
      });
    }
    return function cleanup() {
      if (isWindows) {
        ps.destroy();
      }
    };
  });

  return (
    <div className="sidebar" data-color={'red'}>
      <div className="logo">
        <div className="logo-img">
          <img src={logo} alt="react-logo" />
        </div>
      </div>
      <div className="sidebar-wrapper" ref={sidebar}>
        <Nav>
          {props.routes.map((prop, key) => {
            if (prop.redirect) return null;
            return (
              <li
                className={
                  activeRoute(prop.layout + prop.path) +
                  (prop.pro ? " active active-pro" : "")
                }
                key={key}
              >
                <NavLink to={prop.layout + prop.path} className="nav-link">
                  <i className={"now-ui-icons " + prop.icon} />
                  <p>{prop.name}</p>
                </NavLink>
              </li>
            );
          })}
        </Nav>
      </div>
    </div>
  );
}

export default Sidebar;
