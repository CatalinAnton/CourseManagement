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
  Input,
  FormText
} from 'reactstrap'

class ResourceModal extends Component {
  initialState = {
    name: '',
    description: '',
    file: '',
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
      file: event.target.files
    })
  }

  submitForm = () => {
    alert('a dat submit, am ajuns aici')
    this.setState({ ...this.initialState })
  }

  render() {
    const { name, description, modal } = this.state
    return (
      <div>
        <Button color="link" onClick={this.toggle(true)}>
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
                <Label for="resourceName">Link</Label>
                <Input
                  type="text"
                  name="resourceName"
                  id="link"
                  placeholder="Resource name"
                  onChange={this.changeField('name')}
                  value={name}
                />
              </FormGroup>
              <FormGroup>
                <Label for="fileDescription">Description</Label>
                <Input
                  type="textarea"
                  name="description"
                  id="fileDescription"
                  placeholder="File description"
                  onChange={this.changeField('description')}
                  value={description}
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
            <Button color="primary" onClick={this.toggle(false)}>
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

export default ResourceModal
