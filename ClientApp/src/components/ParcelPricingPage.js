import React, { useState } from 'react';
import {
    Form,
    FormGroup,
    Label,
    Input,
    Button,
    Card,
    CardBody,
    CardTitle
  } from 'reactstrap';
  
const ParcelPricingPage = () => {
  const [dimensions, setDimensions] = useState({
    width: 0,
    height: 0,
    depth: 0
  });
  const [weight, setWeight] = useState(0);

  const [price, setPrice] = useState(0);
  const [validationError, setValidationError] = useState(null);

  const handleDimensionChange = (e) => {
    const { name, value } = e.target;
    setDimensions({
      ...dimensions,
      [name]: value
    });
  };

  const handleWeightChange = (e) => {
    const { value } = e.target;
    setWeight(value);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // Send the package dimensions and weight to the backend for calculation
  };

  const handleResponse = (response) => {
    if (response.ok) {
      // Display the calculated price
      setPrice(response.data.price);
      setValidationError(null);
    } else {
      // Display the validation error
      setPrice(0);
      setValidationError(response.data.validationError);
    }
  };

  return (
    <Card className="p-3 mt-3">
      <CardBody>
        <CardTitle>Parcel Pricing Calculator</CardTitle>
        <Form onSubmit={handleSubmit}>
          <FormGroup>
            <Label for="width">Width:</Label>
            <Input
              type="number"
              name="width"
              id="width"
              value={dimensions.width}
              onChange={handleDimensionChange}
            />
          </FormGroup>
          <FormGroup>
            <Label for="height">Height:</Label>
            <Input
              type="number"
              name="height"
              id="height"
              value={dimensions.height}
              onChange={handleDimensionChange}
            />
          </FormGroup>
          <FormGroup>
            <Label for="depth">Depth:</Label>
            <Input
              type="number"
              name="depth"
              id="depth"
              value={dimensions.depth}
              onChange={handleDimensionChange}
            />
          </FormGroup>
          <FormGroup>
            <Label for="weight">Weight:</Label>
            <Input
              type="number"
              name="weight"
              id="weight"
              value={weight}
              onChange={handleWeightChange}
            />
          </FormGroup>
          <Button type="submit">Calculate Price</Button>
        </Form>
      {validationError && (
        <p>
          <strong>Error:</strong> {validationError}
        </p>
      )}
      {price > 0 && (
        <p>
          The price for your package is: <strong>{price}</strong>
        </p>
      )}
    </CardBody>
    </Card>
  );
};

export default ParcelPricingPage;