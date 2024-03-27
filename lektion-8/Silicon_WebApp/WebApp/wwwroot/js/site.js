document.addEventListener('DOMContentLoaded', function () {

    darkModeSwitch()
    select()
    search()

})


function darkModeSwitch() {

    try {

        let sw = document.querySelector('#switch-mode')
        sw.addEventListener('change', function () {
            let mode = this.checked ? 'dark' : 'light'

            localStorage.setItem('mode', mode)
            sessionStorage.setItem('mode', mode)


            fetch(`/sitesettings/theme?mode=${mode}`)
                .then(res => {
                    if (res.ok)
                        window.location.reload()
                    else
                        console.log('unable to switch theme mode')
                })
        })

    }
    catch { }
}

function select() {
    try {
        let select = document.querySelector('.select')
        let selected = select.querySelector('.selected')
        let selectOptions = select.querySelector('.select-options')

        selected.addEventListener('click', function () {
            selectOptions.style.display = (selectOptions.style.display === 'block') ? 'none': 'block'
        })

        let options = selectOptions.querySelectorAll('.option')
        options.forEach(function (option) {
            option.addEventListener('click', function () {
                selected.innerHTML = this.textContent
                selectOptions.style.display = 'none'
                let category = this.getAttribute('data-value')

                updateCoursesByFilter(category)
            })
        })

    }
    catch { }
}

function search() {
    try {

        document.querySelector('#searchQuery').addEventListener('keyup', function () {
            const searchValue = this.value
            const category = document.querySelector('.select .selected').getAttribute('data-value') || 'all'
            const url = `/courses/index?category=${encodeURIComponent(category)}&searchQuery=${encodeURIComponent(searchValue)}`

            fetch(url)
                .then(res => res.text())
                .then(data => {
                    const parser = new DOMParser()
                    const dom = parser.parseFromString(data, 'text/html')
                    document.querySelector('.items').innerHTML = dom.querySelector('.items').innerHTML

                    const pagination = dom.querySelector('.pagination') ? dom.querySelector('.pagination').innerHTML : ''
                    document.querySelector('.pagination').innerHTML = pagination

                })
        })

    }
    catch { }
}


function updateCoursesByFilter(category) {
    const searchValue = document.getElementById('searchQuery').value
    const url = `/courses/index?category=${encodeURIComponent(category)}&searchQuery=${encodeURIComponent(searchValue)}`

    fetch(url)
        .then(res => res.text())
        .then(data => {
            const parser = new DOMParser()
            const dom = parser.parseFromString(data, 'text/html')
            document.querySelector('.items').innerHTML = dom.querySelector('.items').innerHTML

            const pagination = dom.querySelector('.pagination') ? dom.querySelector('.pagination').innerHTML : ''
            document.querySelector('.pagination').innerHTML = pagination

        })
}