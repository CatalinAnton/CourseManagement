import React, {Component} from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Form, FormGroup, Label, Input } from 'reactstrap';

class LinkForm extends Component{
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
                <Button color="link" onClick={this.toggle}>Add Link</Button>
                <Modal isOpen={this.state.modal} toggle={this.toggle} className={this.props.className}>
                    <ModalHeader toggle={this.toggle}>New Link Reference</ModalHeader>
                    <ModalBody>
                        <Form>
                            <FormGroup>
                                <Label for="link">Link</Label>
                                <Input type="text" name="title" id="link" placeholder="Course title" />
                            </FormGroup>
                            <FormGroup>
                                <Label for="linkDescription">Description</Label>
                                <Input type="textarea" name="description" id="linkDescription" placeholder="Course description" />
                            </FormGroup>
                            <FormGroup>
                                <Label for="placeholderLink">Link placeholder (optional)</Label>
                                <Input type="text" name="date" id="placeholderLink" placeholder="link placeholder" />
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

export default LinkForm;