import React, { Component } from "react";

class LoginView extends Component {
  constructor(props) {
    super(props);
    this.state = { userName: props.UserName, password: "" };
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(event) {
    this.setState({ userName: event.target.value });
  }

  handleChange(event) {
    this.setState({ userName: event.target.value });
  }

  handleSubmit(event) {
    alert("A name was submitted: " + this.state.userName);
    event.preventDefault();
  }

  render() {
    return (
      <form onSubmit={this.handleSubmit}>
        <label>
          User Name
          <input
            type="text"
            value={this.state.userName}
            onChange={this.handleChange}
          />
        </label>
        {/* <label>
          Password
          <input
            type="password"
            value={this.state.password}
            onChange={this.handleChange}
          />
        </label> */}
        <input type="submit" value="Submit" />
      </form>
    );
  }
}

export default LoginView;
