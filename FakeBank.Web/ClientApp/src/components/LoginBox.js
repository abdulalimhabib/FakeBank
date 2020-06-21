import React, { Component } from "react";

export class LoginBox extends Component {
  static displayName = Login.name;

  render() {
    return (
      <div>
        <table>
          <tr>
            <td>Please login to access your account: </td>
          </tr>
          <tr>
            <td>User Name</td>
            <td></td>
          </tr>
          <tr>
            <td>Password</td>
            <td></td>
          </tr>
        </table>
      </div>
    );
  }
}
