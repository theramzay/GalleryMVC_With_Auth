var Content = React.createClass({
    loadFromServer: function () {
        var xhr = new XMLHttpRequest();
        var req = $("#search").val();
        xhr.open("get", this.props.url + "/?search=" + req, true);
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
        this.loadFromServer();
        window.setInterval(this.loadFromServer, this.props.pollInterval);
    },
    render: function () {
        return (
            <div className="grid">
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

function Rend() {
    React.render(<Content url="/api/WebApis/GetFound" pollInterval={200000} />, document.getElementById("content"));
}

//$('body').on('change','#search',(function (e) {
//    e.preventDefault();
//    React.render(<Content url="/api/WebApis/GetFound" pollInterval={200000} />, document.getElementById("content"));
//}));

$('.navbar-collapse').on('input', '#search', function (e) {
    e.preventDefault();
     React.render(<Content url="/api/WebApis/GetFound" pollInterval={200000} />, document.getElementById("content"));
});