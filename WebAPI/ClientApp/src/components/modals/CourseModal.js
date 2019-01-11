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
    Title: '',
    Description: '',
    Year: '',
    Semester: '',
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
    const { Title, Description, Year, Semester } = this.state
    try {
      await promiseDispatch(postCourse, { Title, Description, Year, Semester })
      await promiseDispatch(getCourses)
      this.setState({ ...this.initialState })
    } catch (error) {
      console.log('Error on UI while submitting form', error)
    }
  }

  render () {
    const { Title, Description, Semester, Year, modal } = this.state
    return (
      <div>
        <Button color='success' onClick={this.toggle(true)}>
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
                <Label for='courseTitle'>Title</Label>
                <Input
                  type='text'
                  name='title'
                  id='courseTitle'
                  placeholder='Course title'
                  onChange={this.changeField('Title')}
                  value={Title}
                />
              </FormGroup>
              <FormGroup>
                <Label for='courseDescription'>Description</Label>
                <Input
                  type='textarea'
                  name='description'
                  id='courseDescription'
                  placeholder='Course description'
                  onChange={this.changeField('Description')}
                  value={Description}
                />
              </FormGroup>
              <FormGroup>
                <Label for='courseYear'>Year</Label>
                <Input
                  type='textarea'
                  placeholder='Year'
                  id='courseYear'
                  onChange={this.changeField('Year')}
                  value={Year}
                />
              </FormGroup>
              <FormGroup>
                <Label for='courseSemester'>Semester</Label>
                <Input
                  type='textarea'
                  placeholder='Semester'
                  id='courseSemester'
                  onChange={this.changeField('Semester')}
                  value={Semester}
                />
              </FormGroup>
            </Form>
          </ModalBody>
          <ModalFooter>
            <Button color='primary' onClick={this.submitForm}>
              Done
            </Button>{' '}
            <Button color='secondary' onClick={this.toggle(false)}>
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
