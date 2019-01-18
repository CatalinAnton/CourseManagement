export default (() => {
  const headers = {
    'Authorization': 'rAIgg5w8fBeXdXOThITnIOi9',
    'Content-Type': 'application/json'
  }

  const Fetch = (method, location, body = undefined) => {
    const response = fetch(
      location,
      {
        method,
        headers,
        ...(body && { body: JSON.stringify(body) }),
        mode: 'cors',
        credentials: 'same-origin'
      }
    )

    return {
      toText: () => response.then(async data => ({ status: data.status, statusText: data.statusText, data: await data.text() })),
      toJson: () => response.then(async data => ({ status: data.status, statusText: data.statusText, data: await data.json() })),
      toBlob: () => response.then(async data => ({ status: data.status, statusText: data.statusText, data: await data.blob() }))
    }
  }

  const GET = (location) => Fetch('GET', location)

  const POST = (location, body) => Fetch('POST', location, body)

  const PUT = (location, body) => Fetch('PUT', location, body)

  const PATCH = (location, body) => Fetch('PATCH', location, body)

  const DELETE = (location, body) => Fetch('DELETE', location, body)

  const setHeader = (header, value) => {
    headers[header] = value
  }

  return {
    GET,
    POST,
    PUT,
    PATCH,
    DELETE,
    setHeader
  }
})()
