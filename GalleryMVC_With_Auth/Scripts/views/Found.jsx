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
            <img className="lazy" src={p.TmbPath} data-original={p.TmbPath} alt={p.Description} />
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


$('body').on('input', '#search', (function () {
    $.getScript("/bundles/galmagic?v=i3kUWqQQpdXyuxIE00qkjs5ynWxapRWXXmicTk_JDKE1");
    React.render(<Content url="/api/WebApis/GetFound" />, document.getElementById("images"));
}));