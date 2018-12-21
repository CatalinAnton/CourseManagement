import React, { Component } from 'react'
import { connect } from 'react-redux'
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

import { promiseDispatch } from '../../common'
import { getCourses, postCourse } from '../../courses'

class CourseModal extends Component {
  initialState = {
    title: '',
    description: '',
    date: '',
    modal: false
  }
  state = { ...this.initialState }

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

  submitForm = async () => {
    const { getCourses, postCourse } = this.props
    const { title, description, date } = this.state
    try {
      await promiseDispatch(postCourse, { title, description, date })
      await promiseDispatch(getCourses)
      this.setState({ ...this.initialState })
    } catch (error) {
      console.log('Error on UI while submitting form', error)
    }
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

const mapDispatchToProps = {
  getCourses,
  postCourse
}

export default connect(
  null,
  mapDispatchToProps
)(CourseModal)
