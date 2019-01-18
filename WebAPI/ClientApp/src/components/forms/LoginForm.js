import React, { Component } from 'react'
import {
  Form,
  FormGroup,
  Label,
  CardTitle,
  Input,
  InputGroup,
  InputGroupAddon,
  Button,
  ButtonGroup
} from 'reactstrap'
import { withRouter } from 'react-router-dom'
import { connect } from 'react-redux'

import { promiseDispatch } from '../../common'
import { doLogin } from '../../auth'

class LoginForm extends Component {
  state = {
    email: '',
    password: '',
    loading: false
  }

  _handleChange = field => event => {
    this.setState({
      [field]: event.target.value
    })
  }

  _handleSubmit = async event => {
    const { email, password } = this.state
    const { history, doLogin } = this.props
    event.preventDefault()

    this.setState({ loading: true })

    try {
      await promiseDispatch(doLogin, { email, password })
      history.push('/dashboard')
    } catch (error) {
      console.log('Error on UI', error)
      this.setState({ loading: false })
    }
  }

  render () {
    const { email, password } = this.state
    const { changeForm } = this.props
    return (
      <Form onSubmit={this._handleSubmit}>
        <CardTitle>Login</CardTitle>
        <FormGroup>
          <Label>Email</Label>
          <InputGroup>
            <InputGroupAddon addonType='prepend'> @ </InputGroupAddon>
            <Input
              type='text'
              onChange={this._handleChange('email')}
              value={email}
            />
          </InputGroup>
          <Label>Password</Label>
          <InputGroup>
            <InputGroupAddon addonType='prepend'>**</InputGroupAddon>
            <Input
              type='password'
              onChange={this._handleChange('password')}
              value={password}
            />
          </InputGroup>
        </FormGroup>
        <FormGroup>
          <ButtonGroup>
            <Button color='primary' onClick={this._handleSubmit}>Login</Button>
            <Button onClick={changeForm}>Register</Button>
          </ButtonGroup>
        </FormGroup>
      </Form>
    )
  }
}

const mapDispatchToProps = {
  doLogin
}

export default connect(
  null,
  mapDispatchToProps
)(withRouter(LoginForm))
