import React, {Component} from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter, Form, FormGroup, Label, Input } from 'reactstrap';

class CourseForm extends Component{
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
                <Button color="success" onClick={this.toggle}>Add Course</Button>
                <Modal isOpen={this.state.modal} toggle={this.toggle} className={this.props.className}>
                    <ModalHeader toggle={this.toggle}>New Course</ModalHeader>
                    <ModalBody>
                        <Form>
                            <FormGroup>
                                <Label for="courseTitle">Title</Label>
                                <Input type="text" name="title" id="courseTitle" placeholder="Course title" />
                            </FormGroup>
                            <FormGroup>
                                <Label for="courseDescription">Description</Label>
                                <Input type="textarea" name="description" id="courseDescription" placeholder="Course description" />
                            </FormGroup>
                            <FormGroup>
                                <Label for="courseDate">Date</Label>
                                <Input type="date" name="date" id="courseDate" placeholder="date placeholder" />
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

export default CourseForm;