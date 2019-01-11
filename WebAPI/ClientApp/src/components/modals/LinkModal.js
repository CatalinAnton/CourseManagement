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
import { getResources, postResource } from '../../resources'

class LinkModal extends Component {
  initialState = {
    Title: '',
    Description: '',
    Link: '',
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
    const { courseId, getResources, postResource } = this.props
    const { Title, Description, Link } = this.state
    try {
      await promiseDispatch(postResource, {
        Title,
        Description,
        Link,
        CourseId: courseId,
        Type: 'link'
      })
      await promiseDispatch(getResources)
      this.setState({ ...this.initialState })
    } catch (error) {
      console.log('Error on UI while submitting form', error)
    }
  }

  render () {
    const { Title, Description, Link, modal } = this.state
    return (
      <div>
        <Button onClick={this.toggle(true)}>Add Link</Button>
        <Modal
          isOpen={modal}
          toggle={this.toggle(false)}
          className={this.props.className}
        >
          <ModalHeader toggle={this.toggle(false)}>
            New Link Reference
          </ModalHeader>
          <ModalBody>
            <Form>
              <FormGroup>
                <Label for='title'>Title</Label>
                <Input
                  type='text'
                  name='title'
                  id='title'
                  placeholder='Resource title'
                  onChange={this.changeField('Title')}
                  value={Title}
                />
              </FormGroup>
              <FormGroup>
                <Label for='linkDescription'>Resource description</Label>
                <Input
                  type='textarea'
                  name='description'
                  id='linkDescription'
                  placeholder='Resource description'
                  onChange={this.changeField('Description')}
                  value={Description}
                />
              </FormGroup>
              <FormGroup>
                <Label for='placeholderLink'>Resource link</Label>
                <Input
                  type='text'
                  name='date'
                  id='placeholderLink'
                  placeholder='Resource link'
                  onChange={this.changeField('Link')}
                  value={Link}
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
  getResources,
  postResource
}

export default connect(
  null,
  mapDispatchToProps
)(LinkModal)
