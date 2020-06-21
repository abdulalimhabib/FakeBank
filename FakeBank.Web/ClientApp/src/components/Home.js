import React, { Component } from "react";
import LoginView from "./LoginView";

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h3>Welcome to Fake Bank</h3>
        <LoginView />
      </div>
    );
  }
}
