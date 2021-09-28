import { messages } from './messages'
import axios from 'axios'

async function main() {
    for (let i = 0; i < messages.length; i++) {
        const message = messages[i]
        let endpoint = 'shipment'
        if (message.type === 'ORGANIZATION') {
            endpoint = 'organization'
        }

        try {
            var response = await axios.post(`http://localhost:5000/${endpoint}`, message)
            console.log(response.request.res.headers)
        } catch (error) {
            console.error(error)
        }

    }
}

main()