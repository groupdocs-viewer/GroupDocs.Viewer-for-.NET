module.exports = {
  name: 'viewer',
  preset: '../../jest.config.js',
  coverageDirectory: '../../coverage/apps/viewer',
  snapshotSerializers: [
    'jest-preset-angular/AngularSnapshotSerializer.js',
    'jest-preset-angular/HTMLCommentSerializer.js'
  ]
};
