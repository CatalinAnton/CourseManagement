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
import { register } from '../../auth'

class RegisterForm extends Component {
  state = {
    email: '',
    password: '',
    firstName: '',
    lastName: '',
    role: '',
    loading: false
  }

  _handleChange = field => event => {
    this.setState({
      [field]: event.target.value
    })
  }

  _handleSubmit = async event => {
    const { email, password, firstName, lastName, role } = this.state
    const { history, register } = this.props
    event.preventDefault()

    this.setState({ loading: true })

    try {
      await promiseDispatch(register, { email, password, firstName, lastName, role })
      history.push('/')
    } catch (error) {
      console.log('Error on UI', error)
      this.setState({ loading: false })
    }
  }

  render () {
    const { email, password, firstName, lastName, role } = this.state
    const { changeForm } = this.props
    return (
      <Form onSubmit={this._handleSubmit}>
        <CardTitle>Register</CardTitle>
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
          <Label>First name</Label>
          <InputGroup>
            <InputGroupAddon addonType='prepend'>Fi</InputGroupAddon>
            <Input
              type='text'
              onChange={this._handleChange('firstName')}
              value={firstName}
            />
          </InputGroup>
          <Label>Last name</Label>
          <InputGroup>
            <InputGroupAddon addonType='prepend'>La</InputGroupAddon>
            <Input
              type='text'
              onChange={this._handleChange('lastName')}
              value={lastName}
            />
          </InputGroup>
          <Label>Role</Label>
          <InputGroup>
            <InputGroupAddon addonType='prepend'>Ro</InputGroupAddon>
            <select
              type='text'
              onChange={this._handleChange('role')}
              value={role}
            >
              <option>student</option>
              <option>teacher</option>
            </select>
          </InputGroup>
        </FormGroup>
        <FormGroup>
          <ButtonGroup>
            <Button color='primary' onClick={this._handleSubmit}>Register</Button>
            <Button onClick={changeForm}>Go back</Button>
          </ButtonGroup>
        </FormGroup>
      </Form>
    )
  }
}

const mapDispatchToProps = {
  register
}

export default connect(
  null,
  mapDispatchToProps
)(withRouter(RegisterForm))
