import React, { Component } from 'react'
import {
  Button,
  Modal,
  ModalHeader,
  ModalBody,
  ModalFooter,
  Form,
  FormGroup,
  Label,
  Input
} from 'reactstrap'

class CourseModal extends Component {
  state = {
    title: '',
    description: '',
    date: '',
    modal: false
  }

  toggle = value => () => {
    this.setState({
      modal: value
    })
  }

  changeField = field => event => {
    this.setState({
      [field]: event.target.value
    })
  }

  submitForm = () => {
  }

  render() {
    const { title, description, date, modal } = this.state
    return (
      <div>
        <Button color="success" onClick={this.toggle(true)}>
          Add Course
        </Button>
        <Modal
          isOpen={modal}
          toggle={this.toggle(false)}
          className={this.props.className}
        >
          <ModalHeader toggle={this.toggle(false)}>New Course</ModalHeader>
          <ModalBody>
            <Form>
              <FormGroup>
                <Label for="courseTitle">Title</Label>
                <Input
                  type="text"
                  name="title"
                  id="courseTitle"
                  placeholder="Course title"
                  onChange={this.changeField('title')}
                  value={title}
                />
              </FormGroup>
              <FormGroup>
                <Label for="courseDescription">Description</Label>
                <Input
                  type="textarea"
                  name="description"
                  id="courseDescription"
                  placeholder="Course description"
                  onChange={this.changeField('description')}
                  value={description}
                />
              </FormGroup>
              <FormGroup>
                <Label for="courseDate">Date</Label>
                <Input
                  type="date"
                  name="date"
                  id="courseDate"
                  placeholder="date placeholder"
                  onChange={this.changeField('date')}
                  value={date}
                />
              </FormGroup>
            </Form>
          </ModalBody>
          <ModalFooter>
            <Button color="primary" onClick={this.submitForm}>
              Done
            </Button>{' '}
            <Button color="secondary" onClick={this.toggle(false)}>
              Cancel
            </Button>
          </ModalFooter>
        </Modal>
      </div>
    )
  }
}

export default CourseModal
