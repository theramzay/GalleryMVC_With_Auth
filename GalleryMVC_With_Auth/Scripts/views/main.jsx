var Albums = React.createClass({
    loadAlbumsFromServer: function () {
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
        this.loadAlbumsFromServer();
        window.setInterval(this.loadAlbumsFromServer, this.props.pollInterval);
    },
    //componentWillReceiveProps: function () {  //TODO: create one get
    //    this.loadFromServer();
    //},
    render: function () {
        return (
            <div>
                    {this.state.data.map(
                    function(a) {
                    return (
                        <figure className="effect-lily">
            <img src={a.ImgPath} alt="img01" />
            <figcaption>
                <h2><span>{a.Name}</span></h2>
                <p>{a.Description}</p>
                <a href="#pictures" onClick={ImageSwitch.bind(this,a.Id)}>Открыть</a>
            </figcaption>
                        </figure>
                    );
                    })}
                </div>
            );
    }
});

var Pictures = React.createClass({
    loadFromServer: function () {
        var xhr = new XMLHttpRequest();
        xhr.open("get", this.props.url, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        }.bind(this);
        xhr.send();
    },
    getInitialState: function () {
        return { data: [] };
    },
    componentWillReceiveProps: function () {
        this.loadFromServer();
    },
    render: function () {
        return (
            <div>
    <div id="links">
        {this.state.data.map(function(p) {
            return (
            <figure className="effect-milo">
                <img className="lazy" data-original={p.TmbPath} alt={p.Description} />
                <figcaption>
                    <h2>
                        <span>{p.Description}</span>
                    </h2>
                    <p>Автор - {p.Name}.</p>
                    <p>Цена - {p.Price} бел.руб.</p>
                    <a className="pic" id="links" href={p.Path} title={p.Name}></a>
                </figcaption>
            </figure>);
        })}
    </div>
            </div>
        );
    }
});


var ImageSwitch = function (id, o) {
    var url = "/api/WebApis/GetPictures/?id=" + id;
    React.render(<Pictures url={url} />, document.getElementById('pictures'));
}


React.render(<Albums url="/api/WebApis/GetAlbums" pollInterval={200000} />, document.getElementById('albums'));