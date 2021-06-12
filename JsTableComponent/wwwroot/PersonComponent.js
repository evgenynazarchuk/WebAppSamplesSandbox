/*
 * 
 * Sample Easy Component
 * 
 */

class PersonComponent extends HTMLElement {
    connectedCallback() {

        this.updateTable()
    }

    updateTable() {
        (async () => {

            let uri = this.getAttribute('uri') || undefined
            let responseMessage = await fetch(uri)
            let persons = await responseMessage.json()

            let table = document.createElement('table');
            let personRowHeader = document.createElement('tr')
            let firstNameColumnHeader = document.createElement('th')
            let lastNameColumnHeader = document.createElement('th')

            firstNameColumnHeader.innerText = 'First Name'
            lastNameColumnHeader.innerText = 'Last Name'

            personRowHeader.appendChild(firstNameColumnHeader)
            personRowHeader.appendChild(lastNameColumnHeader)

            table.appendChild(personRowHeader)

            for (let person of persons) {

                let personRow = document.createElement('tr')
                let firstNameColumn = document.createElement('td')
                let lastNameColumn = document.createElement('td')

                firstNameColumn.innerHTML = person.firstName
                lastNameColumn.innerHTML = person.lastName

                personRow.appendChild(firstNameColumn)
                personRow.appendChild(lastNameColumn)

                table.appendChild(personRow)
            }

            this.innerHTML = ''
            this.appendChild(table)

            let updateButton = document.createElement('button')
            updateButton.innerText = "Update"
            updateButton.onclick = () => this.updateTable()

            this.appendChild(updateButton)

        })();
    }
}

customElements.define('person-component', PersonComponent)