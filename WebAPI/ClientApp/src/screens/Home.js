import React, { Component } from 'react'
import {
  Card,
  CardHeader,
  CardBody,
  CardTitle,
  Container,
  Row,
  Col
} from 'reactstrap'

import { RegisterForm, LoginForm } from '../components'

class Home extends Component {
  state = {
    form: 'login'
  }

  _changeForm = form => () => {
    this.setState({
      form
    })
  }

  render () {
    const { form } = this.state
    return (
      <Container>
        <Row>
          <Col sm={{ size: 12, offset: 0, order: 0 }}>
            <Card>
              <CardHeader>
                <CardTitle>Welcome!</CardTitle>
              </CardHeader>
              <CardBody>
                {form === 'login' ? (
                  <LoginForm changeForm={this._changeForm('register')} />
                ) : (
                  <RegisterForm changeForm={this._changeForm('login')} />
                )}
              </CardBody>
            </Card>
          </Col>
        </Row>
      </Container>
    )
  }
}

export default Home
