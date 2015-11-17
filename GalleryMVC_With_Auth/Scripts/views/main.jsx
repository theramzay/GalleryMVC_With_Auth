﻿var Content = React.createClass({
    loadHumansFromServer: function () {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        }.bind(this);
        xhr.send();
    },
    getInitialState: function () {
        return { data: [] };
    },
    componentDidMount: function () {
        this.loadHumansFromServer();
        window.setInterval(this.loadHumansFromServer, this.props.pollInterval);
    },
    render: function () {
        return (
            <div>
                    {this.state.data.map(
                    function(a) {
                    return (
                        <figure className="effect-lily">
            <img src="{a.ImgPath}" alt="img01" />
            <figcaption>
                <h2><span>{a.Name}</span></h2>
                <p>{a.Description}</p>
                <a href="#">Открыть</a>
            </figcaption>
                        </figure>
                    );
                    })}
                </div>
            );
    }
});


React.render(<Content url="/api/WebApis/GetAlbums" pollInterval={200000} />, document.getElementById('content'));