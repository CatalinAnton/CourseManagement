import React, { Component } from 'react'
import {
  Card,
  CardHeader,
  CardBody,
  CardTitle,
  Form,
  FormGroup,
  Label,
  Input,
  InputGroup,
  InputGroupAddon,
  Button,
  ButtonGroup,
  Container,
  Row,
  Col
} from 'reactstrap'
import { withRouter } from 'react-router-dom'

class Home extends Component {
  _handleSubmit = event => {
    const { history } = this.props
    history.push('/teacher_courses')
  }

  render () {
    return (
      <Container>
        <Row>
          <Col sm={{ size: 12, offset: 0, order: 0 }}>
            <Card>
              <CardHeader>
                <CardTitle>Welcome!</CardTitle>
              </CardHeader>
              <CardBody>
                <Form onSubmit={this._handleSubmit}>
                  <FormGroup>
                    <Label>Username</Label>
                    <InputGroup>
                      <InputGroupAddon addonType='prepend'> @ </InputGroupAddon>
                      <Input type='text' />
                    </InputGroup>
                    <Label>Password</Label>
                    <InputGroup>
                      <InputGroupAddon addonType='prepend'>**</InputGroupAddon>
                      <Input type='password' />
                    </InputGroup>
                  </FormGroup>
                  <FormGroup>
                    <ButtonGroup>
                      <Button color='primary'>Login</Button>
                      <Button>Register</Button>
                    </ButtonGroup>
                  </FormGroup>
                </Form>
              </CardBody>
            </Card>
          </Col>
        </Row>
      </Container>
    )
  }
}

export default withRouter(Home)
