import React, {Component} from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Form, FormGroup, Label, Input, FormText } from 'reactstrap';

class ResourceForm extends Component{
    constructor(props) {
        super(props);
        this.state = {
            modal: false
        };

        this.toggle = this.toggle.bind(this);
    }

    toggle() {
        this.setState({
            modal: !this.state.modal
        });
    }

    submitForm(){
        alert("a dat submit, am ajuns aici");
    }

    render(){
        return(
            <div>
                <Button color="link" onClick={this.toggle}>Upload File</Button>
                <Modal isOpen={this.state.modal} toggle={this.toggle} className={this.props.className}>
                    <ModalHeader toggle={this.toggle}>Resource Upload</ModalHeader>
                    <ModalBody>
                        <Form>
                            <FormGroup>
                                <Label for="resourceName">Link</Label>
                                <Input type="text" name="resourceName" id="link" placeholder="Resource name" />
                            </FormGroup>
                            <FormGroup>
                                <Label for="fileDescription">Description</Label>
                                <Input type="textarea" name="description" id="fileDescription" placeholder="File description" />
                            </FormGroup>
                            <FormGroup>
                                <Label for="resourceFile">File</Label>
                                <Input type="file" name="file" id="resourceFile" />
                                <FormText color="muted">
                                    You can upload a variety of files, such as .pdf, .ppt, .doc and many more
                                </FormText>
                            </FormGroup>
                        </Form>
                    </ModalBody>
                    <ModalFooter>
                        <Button color="primary" onClick={this.toggle}>Done</Button>{' '}
                        <Button color="secondary" onClick={this.toggle}>Cancel</Button>
                    </ModalFooter>
                </Modal>
            </div>
        )
    }
}

export default ResourceForm;