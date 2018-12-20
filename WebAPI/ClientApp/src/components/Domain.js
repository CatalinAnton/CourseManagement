import React, {Component} from 'react';
import { Card, Button, CardHeader, CardFooter, CardBody,
    CardTitle, CardText, ListGroup, ListGroupItem, ListGroupItemHeading, ListGroupItemText, CardLink } from 'reactstrap';
import './Domain.css';
import CourseForm from './forms/CourseForm';
import LinkForm from './forms/LinkForm';
import ResourceForm from './forms/ResourceForm';

class Domain extends Component{
    render(){
        return(
            <div>
                <Card>
                    {/* {state.props.title} and so on to use fetched data  I GUESS :-?*/}
                    <CardHeader>Machine Learning</CardHeader>

                    <CardBody>

                        <CardTitle>Special Title Treatment</CardTitle>
                        <CardText>With supporting text below as a natural lead-in to additional content.</CardText>
                        <ListGroup>
                            <ListGroupItem>
                                <ListGroupItemHeading>Course 1</ListGroupItemHeading>
                                <ListGroupItemText>
                                    Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit.
                                </ListGroupItemText>
                            </ListGroupItem>
                            <ListGroupItem>
                                <ListGroupItemHeading>Course 2</ListGroupItemHeading>
                                <ListGroupItemText>
                                    Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit.
                                </ListGroupItemText>
                            </ListGroupItem>
                            <ListGroupItem>
                                <ListGroupItemHeading>Course 3</ListGroupItemHeading>
                                <ListGroupItemText>
                                    Donec id elit non mi porta gravida at eget metus. Maecenas sed diam eget risus varius blandit.
                                </ListGroupItemText>
                                <ListGroup flush references>
                                    <p>References:</p>

                                    <ListGroupItem yellow tag="a" href="#">Dapibus ac facilisis in</ListGroupItem>
                                    <ListGroupItem tag="a" href="#">Morbi leo risus</ListGroupItem>
                                    <ListGroupItem tag="a" href="#">Porta ac consectetur ac</ListGroupItem>
                                    <ListGroupItem tag="a" href="#">Vestibulum at eros</ListGroupItem>
                                    <ListGroupItem> <LinkForm></LinkForm>  {' or '}  <ResourceForm></ResourceForm> </ListGroupItem>

                                </ListGroup>
                            </ListGroupItem>
                        </ListGroup>
                    <p></p>
                        <CourseForm></CourseForm>
                    </CardBody>
                    <CardFooter>Footer</CardFooter>
                </Card>


            </div>
        )
    }
}

export default Domain;