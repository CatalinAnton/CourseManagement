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
  Input,
  FormText
} from 'reactstrap'

import { promiseDispatch } from '../../common'
import { getResources, postResource } from '../../resources'

class ResourceModal extends Component {
  initialState = {
    Title: '',
    Description: '',
    File: '',
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

  changeFiles = event => {
    this.setState({
      File: event.target.files
    })
  }

  submitForm = async () => {
    const { getResources, postResource } = this.props
    const { Title, Description, File } = this.state
    try {
      await promiseDispatch(postResource, { Title, Description, File, Type: 'file' })
      await promiseDispatch(getResources)
      this.setState({ ...this.initialState })
    } catch (error) {
      console.log('Error on UI while submitting form', error)
    }
  }

  render() {
    const { Title, Description, modal } = this.state
    return (
      <div>
        <Button onClick={this.toggle(true)}>
          Upload File
        </Button>
        <Modal
          isOpen={modal}
          toggle={this.toggle(false)}
          className={this.props.className}
        >
          <ModalHeader toggle={this.toggle(false)}>Resource Upload</ModalHeader>
          <ModalBody>
            <Form>
              <FormGroup>
                <Label for="resourceName">Resource name</Label>
                <Input
                  type="text"
                  name="resourceName"
                  id="link"
                  placeholder="Resource name"
                  onChange={this.changeField('Title')}
                  value={Title}
                />
              </FormGroup>
              <FormGroup>
                <Label for="fileDescription">Resource description</Label>
                <Input
                  type="textarea"
                  name="description"
                  id="fileDescription"
                  placeholder="Resource description"
                  onChange={this.changeField('Description')}
                  value={Description}
                />
              </FormGroup>
              <FormGroup>
                <Label for="resourceFile">File</Label>
                <Input
                  type="file"
                  name="file"
                  id="resourceFile"
                  onInput={this.changeFiles}
                />
                <FormText color="muted">
                  You can upload a variety of files, such as .pdf, .ppt, .doc
                  and many more
                </FormText>
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
  getResources,
  postResource
}

export default connect(
  null,
  mapDispatchToProps
)(ResourceModal)
