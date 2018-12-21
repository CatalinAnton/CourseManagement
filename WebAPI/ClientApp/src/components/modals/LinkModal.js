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

class LinkModal extends Component {
  state = {
    title: '',
    description: '',
    link: '',
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
    alert('a dat submit, am ajuns aici')
  }

  render() {
    const { title, description, link, modal } = this.state
    return (
      <div>
        <Button color="link" onClick={this.toggle(true)}>
          Add Link
        </Button>
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
                <Label for="link">Link</Label>
                <Input
                  type="text"
                  name="title"
                  id="link"
                  placeholder="Course title"
                  onChange={this.changeField('title')}
                  value={title}
                />
              </FormGroup>
              <FormGroup>
                <Label for="linkDescription">Description</Label>
                <Input
                  type="textarea"
                  name="description"
                  id="linkDescription"
                  placeholder="Course description"
                  onChange={this.changeField('description')}
                  value={description}
                />
              </FormGroup>
              <FormGroup>
                <Label for="placeholderLink">Link placeholder (optional)</Label>
                <Input
                  type="text"
                  name="date"
                  id="placeholderLink"
                  placeholder="link placeholder"
                  onChange={this.changeField('link')}
                  value={link}
                />
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

export default LinkModal
