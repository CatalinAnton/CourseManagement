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
    title: '',
    description: '',
    link: '',
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
    const { getResources, postResource } = this.props
    const { title, description, link } = this.state
    try {
      await promiseDispatch(postResource, { title, description, link, type: 'link' })
      await promiseDispatch(getResources)
      this.setState({ ...this.initialState })
    } catch (error) {
      console.log('Error on UI while submitting form', error)
    }
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
                <Label for="title">Title</Label>
                <Input
                  type="text"
                  name="title"
                  id="title"
                  placeholder="Resource title"
                  onChange={this.changeField('title')}
                  value={title}
                />
              </FormGroup>
              <FormGroup>
                <Label for="linkDescription">Resource description</Label>
                <Input
                  type="textarea"
                  name="description"
                  id="linkDescription"
                  placeholder="Resource description"
                  onChange={this.changeField('description')}
                  value={description}
                />
              </FormGroup>
              <FormGroup>
                <Label for="placeholderLink">Resource link</Label>
                <Input
                  type="text"
                  name="date"
                  id="placeholderLink"
                  placeholder="Resource link"
                  onChange={this.changeField('link')}
                  value={link}
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
  getResources,
  postResource
}

export default connect(
  null,
  mapDispatchToProps
)(LinkModal)
