/*
 * 
 * Sample Easy Component
 * 
 */

class HelloWorld extends HTMLElement {
    connectedCallback() {
        var data = this.getAttribute('data') || undefined
        this.innerHTML = data
    }
}

customElements.define('hello-world', HelloWorld)