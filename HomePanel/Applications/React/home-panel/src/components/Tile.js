import React from 'react';

export class Tile extends React.Component {
  render() {
    const viewModel = this.props;

    return (
      <div className="tile">
        Dashboard Tile
        </div>
    )
  }
}

export default Tile