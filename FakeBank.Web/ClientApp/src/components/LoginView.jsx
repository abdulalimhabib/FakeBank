import React, { Component } from "react";

class LoginView extends Component {
  state = {};
  render() {
    return (
      <React.Fragment>
        <table>
          <tr>
            <td colSpan="2">Please login to access your account:</td>
          </tr>
          <tr>
            <td>User Name</td>
            <td>
              <input></input>
            </td>
          </tr>
          <tr>
            <td>Password</td>
            <td>
              <input></input>
            </td>
          </tr>
        </table>
      </React.Fragment>
    );
  }
}

export default LoginView;
